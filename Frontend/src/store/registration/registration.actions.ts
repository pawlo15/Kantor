import { createAction } from "@ngrx/store";

export const registration = createAction("[Registration] Registration");
export const registrationSuccess = createAction("[Registration] Registration Success");
export const registrationFailed = createAction("[Registration] Registration Failed");