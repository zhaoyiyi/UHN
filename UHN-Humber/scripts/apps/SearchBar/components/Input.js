import React from 'react';

export default class Input extends React.Component {

  render() {
    return (
        <div className="input-group">
          <input type="text" className="form-control" name={this.props.inputName}
                 value={this.props.value} onChange={this.props.onChange}
          />
          <span className="input-group-btn">
            <button className="btn btn-default" type="submit">Search</button>
            </span>
        </div>
    )
  }
}