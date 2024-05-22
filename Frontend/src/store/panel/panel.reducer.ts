import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import { onNgrxForms } from "ngrx-forms";
import { GetCurrenciesSuccess, GetUserDetailsSuccess } from "./panel.actions";

const PANEL = "PANEL";

const getPanelState = createFeatureSelector<IPanelState>('panel');

export const getUserDetails = createSelector(getPanelState, state => state.user);
export const getUserAccountBalance = createSelector(getPanelState, state => state.userAccountBalances);
export const getUserHistory = createSelector(getPanelState, state => state.userHistory);
export const getUserOperationHistory = createSelector(getPanelState, state => state.userOperationHistory);
export const getCurrencies = createSelector(getPanelState, state => state.currencies);

export interface IPanelState {
  user: IUserDetails;
  currencies: ICurrency[];
  userAccountBalances: IUserBalance[];
  userHistory: IUserHistory[];
  userOperationHistory: IUserOperationHistory[];
}

export interface IUserDetails {
  id: string;
  login: string;
  name: string;
  email: string;
  secureKey: string;
}

export interface IUserDetailsResponse {
  id: string;
  login: string;
  name: string;
  email: string;
  secureKey: string;
  accountBalances: IUserBalance[];
  history: IUserHistory[];
  operationHistory: IUserOperationHistory[];
}

export interface ICurrencyResponse {
  currencies: ICurrency[];
}

export interface ICurrency {
  name: string;
  purchase: number;
  sale: number;
  validFrom: string;
  validTo: string;
  securityCode: number;
}

export interface IUserBalance {
  currencyId: number;
  balance: number;
  currency: string;
}

export interface IUserHistory {
  action: string;
  date: string;
}

export interface IUserOperationHistory {
  date: string;
  value: number;
  exchangeRate: number;
  totalValue: number;
  currencyCode: string;
  currencyId: number;
  operationType: string;
  operationTypeId: number;
}
const initialStateOperationHistory : IUserOperationHistory = {
  date: '15-12-11',
  value: 321,
  exchangeRate: 156,
  totalValue: 36987.21,
  currencyCode: "USD",
  currencyId: 1,
  operationType: "SALE",
  operationTypeId: 1
}

const initialStateUserDetails : IUserDetails = {
    id: "daf17549-8c36-4be4-8b50-ccecf8874e40",
    email: "pawel@mail.com",
    name: "pawel",
    login: "pawel123",
    secureKey: "ASRMKKKF",
}

const initialState: IPanelState = {
    user: initialStateUserDetails,
    currencies: [],
    userAccountBalances: [],
    userHistory: [],
    userOperationHistory: []
}

const _panelReducer = createReducer<IPanelState>(initialState,
    onNgrxForms(),
    on( GetUserDetailsSuccess, (state, action) => {
        return { ...state, 
          user: action.user, 
          userAccountBalances: action.user.accountBalances,
          userHistory: action.user.history,
          userOperationHistory: action.user.operationHistory 
        }
    }),
    // on( GetCurrenciesSuccess, (state, action) => {
    //     return { ...state,
    //       currencies: action.data.currencies 
    //     }
    // })
)

export function panelReducer(state: any, action: any) {
    return _panelReducer(state, action);
}