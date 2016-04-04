import React from 'react';

export default class MenuItem extends React.Component {
  static defaultProps = {
    collapseButton: ""
  };

  static propTypes = {
    name: React.PropTypes.string.isRequired,
    onChange: React.PropTypes.func.isRequired,
    onDelete: React.PropTypes.func.isRequired,
    collapseButton: React.PropTypes.node
  };

  render() {
    return (
        <div className="panel panel-default" style={{marginBottom: '0px', cursor: 'move'}}>
          {this.props.collapseButton}
          <div className="panel-body" style={{padding: '2px'}}>
            <div className="row">
              <div className="col-xs-5">
                <div className="input-group">
                  <span className="input-group-addon">Name</span>
                  <input type="text" name='name'
                         className="form-control" placeholder="name"
                         value={this.props.name} onChange={this.props.onChange}/>
                </div>
              </div>

              <div className="col-xs-5">
                <div className="input-group">
                  <span className="input-group-addon">Link</span>
                  <input type="text" name='link'
                         className="form-control" placeholder="link"
                         value={this.props.link} onChange={this.props.onChange}/>
                </div>
              </div>

              <div className="col-xs-2">
                <button className="btn btn-danger" onClick={this.props.onDelete}>Delete</button>
              </div>
            </div>
          </div>
        </div>
    );
  }
}