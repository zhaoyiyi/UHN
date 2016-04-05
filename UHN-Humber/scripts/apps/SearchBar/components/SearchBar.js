import React from 'react';
import Input from './Input';
import Suggestion from './Suggestion';

function getData() {
  return [
    {firstName: '12312', lastName: 'lastname', specialty: 'speic', id: '1'},
    {firstName: '123', lastName: 'lastnsdfame', specialty: 'speic', id: '11'},
    {firstName: '1', lastName: 'asdf', specialty: 'asd', id: '2'},
    {firstName: '2', lastName: 'sdf', specialty: 'spesdfic', id: '5'}
  ]
}

export default class SearchBar extends React.Component {

  constructor() {
    super();
    this.state = {
      text: '',
      suggestions: []
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
            value={this.state.text}
            onChange={this.handleInputChange}
      />
        <Suggestion suggestions={this.state.suggestions}/>
      </div>
    )
  }
}