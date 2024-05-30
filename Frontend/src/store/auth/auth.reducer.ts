import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import { FormGroupState, createFormGroupState, onNgrxForms } from "ngrx-forms";
import * as AuthActions from "./auth.actions";

const CREDENTIALS = "CREDENTIALS";

const getAuthState = createFeatureSelector<IAuthState>('auth');

export const getCredentials = createSelector(getAuthState, state => state.credetials);
export const getError = createSelector(getAuthState, state => state.error);

export interface IAuthState {
    credetials: FormGroupState<ICredentials>;
    error: boolean
}

export interface ICredentials {
    login: string,
    password: string
}

export interface IToken {
    accessToken: string,
    refreshToken: string
}

const initialStateCredentials = createFormGroupState<ICredentials>(CREDENTIALS, {
    login: '',
    password: ''
})

export const initialState : IAuthState = {
    credetials: initialStateCredentials,
    error: false
}

const _authReducer = createReducer<IAuthState>(initialState,
    onNgrxForms(),
    on(AuthActions.clearCredentials, (state: any) => {
        return { ...state, credetials: initialState.credetials}
    }),
    on(AuthActions.loginSuccess, (state, action) => {
        sessionStorage.setItem("accessToken", action.token.accessToken);
        sessionStorage.setItem("refreshToken", action.token.refreshToken);
        return { ...state}
    }),
    on(AuthActions.navigateToLoginPage, (state) => {
        sessionStorage.removeItem("accessToken");
        sessionStorage.removeItem("refreshToken");
        return { ...state}
    }),
    on(AuthActions.register, (state: any) => {
        return { ...state, credetials: initialState.credetials}
    }),
    on(AuthActions.loginFailed, (state, action) => {
        return {...state, error: true}
    })
)

export function authReducer(state: any, action: any) {
    return _authReducer(state, action);
}