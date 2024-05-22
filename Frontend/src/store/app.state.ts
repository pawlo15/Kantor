import { ActionReducerMap } from '@ngrx/store';
import * as mainReducer from './main/main.reducer';
import * as authReducer from './auth/auth.reducer';
import * as panelReducer from './panel/panel.reducer';

export interface IAppState {
    main: mainReducer.IMainState;
    auth: authReducer.IAuthState;
    panel: panelReducer.IPanelState;
    // tu dodajemy kolejne state
}

export const appReducer: ActionReducerMap<IAppState> = {
    main: mainReducer.mainReducer,
    auth: authReducer.authReducer,
    panel: panelReducer.panelReducer,
    //tu dodajemy reducery
}