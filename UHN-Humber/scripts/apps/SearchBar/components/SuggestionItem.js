import React from 'react';

export default class SuggestionItem extends React.Component {

    static propTypes = {
        firstName: React.PropTypes.string,
        lastName: React.PropTypes.string,
        id: React.PropTypes.number,
        specialty: React.PropTypes.string
    };

    render() {
        return (
              <a href={`details/${this.props.id}`}>
                {this.props.firstName} {this.props.lastName}, {this.props.specialty}
          </a>

    )
}
}