import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as LoginState from '../store/Login';

type LoginProps = LoginState.LoginState & typeof LoginState.actionCreators & RouteComponentProps<{}>

export class Login extends React.Component<LoginProps, {}> {

    constructor(props: LoginProps) {
        super(props);
        this.state = {};
    }

    handleSubmit(event: any) {
        this.props.loginRequest(this.props.login);
    }

    render() {
        return <div className="login-form">
            <div className="login-form_content login-form_content_vertical-centered">
                <div className="container">
                    <div className="row">
                        <div className="col-md-4 col-md-offset-4">
                            <div className="panel panel-default">
                                <div className="panel-heading">
                                    <p className="panel-title">Please sign in</p>
                                </div>
                                <div className="panel-body">
                                    <form role="form" onSubmit={this.handleSubmit}>
                                        <fieldset>
                                            <div className="form-group">
                                                <input className="form-control" placeholder="E-mail" name="email" type="text" value={this.props.login.email} />
                                            </div>
                                            <div className="form-group">
                                                <input className="form-control" placeholder="Password" name="password" type="password" value={this.props.login.password} />
                                            </div>
                                            <div className="checkbox">
                                                <label>
                                                    <label> <input name="remember" type="checkbox" checked={this.props.login.isPersistent} />Remember Me</label>
                                                </label>
                                            </div>
                                            <input className="btn btn-lg btn-primary btn-block" type="submit" />
                                        </fieldset>
                                    </form>
                                    <div className="text-center login-form__test-page-link login-form__test-page-link_margin-top">
                                        <Link to="/home">See our test page</Link>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>;
    }
}


const mapStateToProps = (state: any) => ({
    login: state.login,
    result: state.result
});


const mapDispatchToProps = (dispatch: any) => ({
    loginRequest: dispatch(LoginState.actionCreators.loginRequest),
    dispatch
});

export default connect(mapStateToProps, mapDispatchToProps)((Login) as any);
