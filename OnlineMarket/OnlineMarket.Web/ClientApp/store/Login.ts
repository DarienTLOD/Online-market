import { Action, Reducer } from 'redux';
import { fetch, addTask } from 'domain-task';
import { AppThunkAction } from './';

export interface LoginState {
    login: LoginModel;
    result: LoginResult;
}

export interface LoginResult {
    errorMessages: string[];
    accessToken: string;
}

export interface LoginModel {
    email: string;
    password: string;
    isPersistent: boolean;
}

interface LoginRequestAction {
    type: 'LOGIN_REQUEST';
    loginModel: LoginModel;
}

interface LoginReceiveAction {
    type: 'LOGIN_RECEIVE';
    result: LoginResult;
}

type KnownAction = LoginRequestAction | LoginReceiveAction;

export const actionCreators = {
    loginRequest: (loginModel: LoginModel): AppThunkAction<KnownAction> => (dispatch) => {
        let fetchTask = fetch(`api/account/login`, { method: 'POST', body: JSON.stringify(loginModel), mode: 'cors' })
            .then(response => response.json() as Promise<LoginResult>)
            .then(data => {
                dispatch({ type: 'LOGIN_RECEIVE', result: data });
            });

        addTask(fetchTask);
        dispatch({ type: 'LOGIN_REQUEST', loginModel: loginModel });
    }
};

const unloadedState: LoginState =
    { login: { email: "", password: "", isPersistent: false }, result: { accessToken: "", errorMessages: [] } };

export const reducer: Reducer<LoginState> = (state: LoginState = unloadedState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'LOGIN_RECEIVE':
            return {
                ...state,
                result: action.result
            };
        case 'LOGIN_REQUEST':
            return {
                ...state,
                login: action.loginModel,
            };
        default:
            return state;
    }
};