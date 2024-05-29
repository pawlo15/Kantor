import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import { FormGroupState, createFormGroupState, onNgrxForms } from "ngrx-forms";
import { ICredentials } from "../auth/auth.reducer";
import * as RegistrationActions from "./registration.actions";

const REGISTRATION = "REGISTRATION";

const getRegistrationState = createFeatureSelector<IRegistrationState>('registration');
export const getRegistrationDetails = createSelector(getRegistrationState, state => state.registrationDetails);

export interface IRegistrationState {
    registrationDetails: FormGroupState<IRegistrationDetails>;
}

export interface IRegistrationDetails {
    login: string,
    password: string,
    name: string,
    email: string
}

const initialStateRegistration = createFormGroupState<IRegistrationDetails>(REGISTRATION, {
    login: '',
    password: '',
    email: '',
    name: ''
})


export const initialState : IRegistrationState = {
    registrationDetails: initialStateRegistration
}

const _registrationReducer = createReducer<IRegistrationState>(initialState,
    onNgrxForms(),
    on(RegistrationActions.registrationSuccess, (state: any) => {
        return {...state, registrationDetails: initialState.registrationDetails}
    })
)

export function registrationReducer(state: any, action: any){
    return _registrationReducer(state, action);
}