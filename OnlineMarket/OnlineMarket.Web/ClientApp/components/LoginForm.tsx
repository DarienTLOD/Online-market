import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { Field, reduxForm } from 'redux-form'

export default class Login extends React.Component<RouteComponentProps<{}>, {}> {
    constructor(props: any) {
        super(props);
        this.state = { login: "", password: "" };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    public handleSubmit(event: any) {
        event.preventDefault();
        const data = new FormData(event.target);

        fetch('/api/form-submit-url', {
            method: 'POST',
            body: data,
        });
    }

    public render() {
        return <form role="form" onSubmit={this.handleSubmit}>
            <fieldset>
                <div className="form-group">
                    <input className="form-control" placeholder="E-mail" name="email" type="text" value="{this.state.login}" />
                </div>
                <div className="form-group">
                    <input className="form-control" placeholder="Password" name="password" type="password" value="{this.state.password}" />
                </div>
                <div className="checkbox">
                    <label>
                        <label> <input name="remember" type="checkbox" />Remember Me</label>
                    </label>
                </div>
                <input className="btn btn-lg btn-primary btn-block" type="submit" />
            </fieldset>
        </form>
            ;
    }
}
