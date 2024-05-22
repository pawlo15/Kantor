import { createAction, props } from "@ngrx/store";
import { ICurrencyResponse, IUserDetailsResponse } from "./panel.reducer";

export const GetUserDetails = createAction("[Panel] Get User Details");
export const GetUserDetailsSuccess = createAction("[Panel] Get User Details Success", props<{ user: IUserDetailsResponse}>());

export const GetCurrencies = createAction("[Panel] Get Currencies");
export const GetCurrenciesSuccess = createAction("[Panel] Get Currencies", props<{ data: ICurrencyResponse }>())