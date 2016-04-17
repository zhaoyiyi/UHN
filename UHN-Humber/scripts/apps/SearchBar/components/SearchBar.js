import React from 'react';
import Input from './Input';
import Suggestion from './Suggestion';


export default class SearchBar extends React.Component {

  constructor() {
    super();
    this.state = {
      text: '',
      suggestions: [],
      path: document.querySelector('#searchBar').getAttribute('data-path')
    };
  }

  handleInputChange = (event) => {
    const value = event.target.value;
    this.setState({text: value});
    
    if (window.suggestionTimeout) clearTimeout(window.suggestionTimeout);

    if (!value || value.length < 3){
        console.log(value);
        this.setState({suggestions: []});
    } else {
        window.suggestionTimeout = setTimeout(() => {
            console.log('getSuggestion');
            $.getJSON('/api/intellisense', {text: value}).then( data => {
                console.log(data);
                this.setState({suggestions: data})
            })
        }, 1000)
    }
  };

  render() {
    return (
      <div>
        <Input
            inputName="searchText"
            value={this.state.text}
            onChange={this.handleInputChange}
      />
        <Suggestion suggestions={this.state.suggestions} path={this.state.path} />
      </div>
    )
  }
}