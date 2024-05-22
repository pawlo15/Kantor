import { createAction, props } from "@ngrx/store";
import { IToken } from "./auth.reducer";

export const login = createAction("[Auth] Login");
export const logout = createAction("[Auth] Logout");

export const loginSuccess = createAction("[Auth] Login Success", props<{ token: IToken }>());
export const loginFailed = createAction("[Auth] Login Failed", props<{ message: string }>());

export const navigateToMainPanel = createAction("[Auth] Navigate To Main Panel");
export const redirectToLoginPage = createAction("[Auth] Redirect To Login Page");

export const clearCredentials = createAction("[Auth] Clear Credentials");