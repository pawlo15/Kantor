import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import * as MainActions from "./main.actions";

export const initialState: IMainState = {
    loading: true,
    APIEndpoint: "https://localhost:7222",
    Version: {
        buildDate: "",
        version: ""
    }
}

export interface IMainState {
    loading: boolean;
    APIEndpoint: string;
    Version: IVersion;
}

export interface IVersion {
    version: string;
    buildDate: string;
}

const getMainState = createFeatureSelector<IMainState>('main');

export const loading = createSelector(getMainState, state => state.loading);

export const getApi = createSelector(getMainState, state => state.APIEndpoint);

export const getVersion = createSelector(getMainState, state => state.Version.version);

const _mainReducer = createReducer<IMainState>(initialState,
    on(MainActions.setIsLoged,(state: any) => {
        return { ...state, IsLogged: true }
    })
)

export function mainReducer(state: any, action: any){
    return _mainReducer(state, action);
}