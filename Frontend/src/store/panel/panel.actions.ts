import { createAction, props } from "@ngrx/store";
import { ICurrencyResponse, IUserDetailsResponse } from "./panel.reducer";

export const GetUserDetails = createAction("[Panel] Get User Details");
export const GetUserDetailsSuccess = createAction("[Panel] Get User Details Success", props<{ user: IUserDetailsResponse}>());

export const GetCurrencies = createAction("[Panel] Get Currencies");
export const GetCurrenciesSuccess = createAction("[Panel] Get Currencies Success", props<{ data: ICurrencyResponse }>());

export const ExchangeCurrency = createAction("[Panel] Exchange Currency");
export const ExchangeCurrencySuccess = createAction("[Panel] Exchange Currency Success");

export const AddMoney = createAction("[Panel] Add Money");
export const AddMoneySuccess = createAction("[Panel] Add Money Success");