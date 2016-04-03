import React from 'react';

export default class MenuDisplay extends React.Component {
  static propTypes = {
    menu: React.PropTypes.array.isRequired
  };

  drawMenu = (menu, isSubmenu = false) => {
    return menu.map((item, index) => {
      let submenu = '';
      let arrow = '';
      let liClass = !isSubmenu ? "nav-item" : "dropdown-submenu";
      let aClass = !isSubmenu ? "dropdown-toggle menu_item" : "dropdown-toggle";
      if ($.isArray(item)) return;
      if ($.isArray(menu[index + 1])) submenu = (
          <div key={index} className="dropdown-menu first_nav">
            <ul className="blue_top">
              {this.drawMenu(menu[index + 1], true)}
            </ul>
          </div>
      );
      if (submenu && isSubmenu) arrow = (
          <span style={{verticalAlign: 'bottom', float: 'right', fontSize: '11px', paddingTop: '3px'}}
                className="glyphicon glyphicon-chevron-right" />
      );
      return (
          <li key={index} className={liClass}>
            <a className={aClass}
               href={`http://${location.hostname}/${item.link}`}>{item.name}
            </a>
            {arrow}
            {submenu}
          </li>
      )
    })
  };

  render() {
    return (
        <div className="main-nav container">
          <div className="Main-nav container">
            <ul id="nav_lg">
              <li className="static"></li>
              {this.drawMenu(this.props.menu)}
              <li className="static2"></li>
            </ul>
          </div>
        </div>
    )
  }
}