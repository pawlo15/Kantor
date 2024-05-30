import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import * as MainActions from "./main.actions";

export const initialState: IMainState = {
    loading: false,
    APIEndpoint: "",
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
    }),
    on(MainActions.setEnviromentSuccess, (state, action) => {
        return { ...state, APIEndpoint: action.url.APIEndpoint, loading: action.url.loading, Version: action.url.Version}
    })
)

export function mainReducer(state: any, action: any){
    return _mainReducer(state, action);
}