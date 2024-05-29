import { ActionReducerMap } from '@ngrx/store';
import * as mainReducer from './main/main.reducer';
import * as authReducer from './auth/auth.reducer';
import * as panelReducer from './panel/panel.reducer';
import * as registrationReducer from './registration/registration.reducer';

export interface IAppState {
    main: mainReducer.IMainState;
    auth: authReducer.IAuthState;
    panel: panelReducer.IPanelState;
    registration: registrationReducer.IRegistrationState;
    // tu dodajemy kolejne state
}

export const appReducer: ActionReducerMap<IAppState> = {
    main: mainReducer.mainReducer,
    auth: authReducer.authReducer,
    panel: panelReducer.panelReducer,
    registration: registrationReducer.registrationReducer
    //tu dodajemy reducery
}