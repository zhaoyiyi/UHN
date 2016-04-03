import React from 'react';
import update from 'react/lib/update';
import MenuTab from './MenuTab';
import MenuItem from './MenuItem';
import MenuStore from '../stores/MenuStore';
import MenuActions from '../actions/MenuActions';
import MenuDisplay from '../../MenuDisplay/components/MenuDisplay';
import '../css/menu.css!';
import $ from 'jquery';
import 'jquery-ui';

Array.prototype.deepSplice = function (indexArray, deleteCount, ...replacement) {
  if (!indexArray) return;
  return indexArray.reduce((acc, currentIndex, i) => {
    console.log(currentIndex);
    if (i < indexArray.length - 1) return acc[currentIndex];
    return acc.splice(currentIndex, deleteCount, ...replacement);
  }, this)
};

export default class EditorContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = MenuStore.getState();
  }

  componentDidMount() {
    MenuStore.addChangeListener(this._onChange);
    MenuActions.getMenu();
  }

  componentDidUpdate() {
    // jquery ui sortable
    $('ul.sortable').sortable({
      connectWith: 'ul.sortable',
      update: this.handleDrop,
      placeholder: 'dndPlaceholder'
    }).disableSelection();

    // Display toastr message
    if (this.state.toastr) this.state.toastr();
  }

  componentWillUpdate() {
    $('ul.sortable').sortable("destroy");
  }

  componentWillUnmount() {
    MenuStore.removeChangeListener(this._onChange);
  }

  _onChange = () => {
    this.setState(MenuStore.getState());
    console.log('change');
  };

  /*****************
   * Methods
   *****************/
  saveMenu = (event) => {
    MenuActions.saveMenu(this.state.menu);
  };

  handleInputChange = (event) => {
    const currentMenu = this.state.menu[this.state.num];
    const type = event.target.getAttribute('name');
    const id = $(event.target).closest('li').data('id');
    const item = id.toString().split('').reduce((acc, item) => {
      return acc[item];
    }, currentMenu.menu);
    item[type] = event.target.value;
    this.setState({
      menu: update(this.state.menu, {
        $apply: (menuState) => {
          menuState[this.state.num] = currentMenu;
          return menuState;
        }
      })
    })
  };

  handleDrop = () => {
    // get current menu
    const menu = this._getMenuItemValue($('#sortableMenu > ul'));
    // get items in new menu section
    const newMenuItems = this._getMenuItemValue($('#newMenu'));
    // Disable jquery dnd, and let React handle DOM update
    $('ul.sortable').sortable('cancel');
    // update
    MenuActions.update(menu, newMenuItems);
  };

  handleDeleteItem = (event) => {
    // get data-id on li element
    const id = $(event.target).closest('li').data('id');
    let menuTree = [].concat(this.state.menu[this.state.num].menu);
    menuTree.deepSplice(id.toString().split(''), 1);
    MenuActions.update(menuTree)
  };

  handleNewItem = () => {
    MenuActions.createMenuItem();
  };
  /*****************
   * Display
   *****************/
  drawMenu = (menuItems, baseIndex = '') => {
    return menuItems.map((item, index) => {
      // don't draw array - submenu
      // unique react id
      const id = baseIndex + index.toString();
      const nextItem = menuItems[index + 1];
      // Set submenu
      let subMenu;
      if ($.isArray(nextItem)) subMenu = this.drawMenu(nextItem, index + 1);
      if ($.isArray(item)) return;
      return (
          <li key={id} data-id={id}>
            <MenuItem  {...item} onChange={this.handleInputChange} onDelete={this.handleDeleteItem}/>
            <ul className="sortable"
                style={{ minHeight: '20px', margin: '0 0 0 2em', padding: '0'}}>
              {subMenu}
            </ul>
          </li>
      );
    })
  };

  render() {
    if (this.state.menu.length === 0) return (<div>loading...</div>);

    return (
        <div className="container-fluid">
          <div className="jumbotron" style={{background: 'white'}}>
            <h1>Menu Editor</h1>
            <MenuDisplay menu={this.state.menu[this.state.num].menu}/>
          </div>
          <div className="row">
            <aside className="col-sm-3">
              <MenuTab menu={this.state.menu} current={this.state.num}/>
            </aside>
            <div ref="sortable" id="sortableMenu" className="col-sm-9">
              <button className="btn btn-success " onClick={this.handleNewItem}>New Item</button>
              <button className="btn btn-primary" onClick={this.saveMenu}>Save</button>

              <ul className="sortable" style={{padding: '2em 0', border: '1px solid pink'}}>
                {this.drawMenu(this.state.menu[this.state.num].menu)}
              </ul>
            </div>
          </div>
        </div>
    );
  }

  /*****************
   * Private
   *****************/
  _getMenuItemValue = (menu) => {
    return $(menu).children().toArray().reduce((acc, item) => {
      acc.push({
        name: $(item).find('input[name="name"]').first().val(),
        link: $(item).find('input[name="link"]').first().val()
      });
      if ($(item).children().find('input').toArray().length > 0) {
        const subItems = this._getMenuItemValue($(item).children('ul'));
        if (subItems && subItems.length > 0) acc.push(subItems);
      }
      return acc;
    }, [])
  };
}