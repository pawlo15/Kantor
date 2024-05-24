import { createAction, props } from "@ngrx/store";
import { IToken } from "./auth.reducer";

export const login = createAction("[Auth] Login");
export const logout = createAction("[Auth] Logout");

export const register = createAction("[Auth] Open Register dialog");

export const loginSuccess = createAction("[Auth] Login Success", props<{ token: IToken }>());
export const loginFailed = createAction("[Auth] Login Failed", props<{ message: string }>());

export const navigateToMainPanel = createAction("[Auth] Navigate To Main Panel");
export const navigateToLoginPage = createAction("[Auth] Navigate To Login Page");

export const clearCredentials = createAction("[Auth] Clear Credentials");