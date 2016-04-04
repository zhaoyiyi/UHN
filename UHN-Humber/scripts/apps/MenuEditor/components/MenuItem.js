import React from 'react';

export default class MenuItem extends React.Component {
  static defaultProps = {
    collapseButton: ""
  };

  static propTypes = {
    nameValueLink: React.PropTypes.object.isRequired,
    linkValueLink: React.PropTypes.object.isRequired,
    onChange: React.PropTypes.func.isRequired,
    onDelete: React.PropTypes.func.isRequired,
    collapseButton: React.PropTypes.node
  };

  shouldComponentUpdate(nextProps) {
    return nextProps.name !== this.props.name || nextProps.link !== this.props.link
  }

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
                         valueLink={this.props.nameValueLink}/>
                </div>
              </div>

              <div className="col-xs-5">
                <div className="input-group">
                  <span className="input-group-addon">Link</span>
                  <input type="text" name='link'
                         className="form-control" placeholder="link"
                         valueLink={this.props.linkValueLink}/>
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