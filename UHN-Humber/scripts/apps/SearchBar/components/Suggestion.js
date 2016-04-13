import React from 'react';
import SuggestionItem from './SuggestionItem';

export default class Suggestion extends React.Component {

  static propTypes = {
    suggestions: React.PropTypes.array.isRequired
  };

  render() {
    return (
        <div>
          <ul className="list-group">
            {this.props.suggestions.map( (suggestion, index) => {
              return (
                  <li key={index} className="list-group-item">
                    <SuggestionItem {...suggestion} path={this.props.path} />
                  </li>
              )
            })}

          </ul>
        </div>
    )
  }
}