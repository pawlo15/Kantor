import { createFeatureSelector, createReducer, createSelector, on } from "@ngrx/store";
import { FormGroupState, createFormGroupState, onNgrxForms, onNgrxFormsAction } from "ngrx-forms";
import { GetCurrenciesSuccess, GetUserDetailsSuccess } from "./panel.actions";

const EXCHANGE = "EXCHANGE";
const ADDMONEY = "ADDMONEY";

const getPanelState = createFeatureSelector<IPanelState>('panel');

export const getUserDetails = createSelector(getPanelState, state => state.user);
export const getUserAccountBalance = createSelector(getPanelState, state => state.userAccountBalances);
export const getUserHistory = createSelector(getPanelState, state => state.userHistory);
export const getUserOperationHistory = createSelector(getPanelState, state => state.userOperationHistory);
export const getCurrencies = createSelector(getPanelState, state => state.currencies);
export const getExchange = createSelector(getPanelState, state => state.exchange);
export const getAddMoneyRequest = createSelector(getPanelState, state => state.addMoneyRequest);

export interface IPanelState {
  user: IUserDetails;
  currencies: ICurrency[];
  userAccountBalances: IUserBalance[];
  userHistory: IUserHistory[];
  userOperationHistory: IUserOperationHistory[];
  exchange: FormGroupState<IExchange>;
  addMoneyRequest: FormGroupState<IAddMoney>;
}

export interface IUserDetails {
  id: string;
  login: string;
  name: string;
  email: string;
  secureKey: string;
}

export interface IAddMoney {
  value: number;
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
  name: string,
  purchase: number,
  sale: number,
  validFrom: string,
  validTo: string,
  securityCode: number
}

export interface IUserBalance {
  currencyId: number;
  balance: number;
  currency: string;
}

export interface IExchange {
  currency: string,
  amount: number,
  isSale: boolean,
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

const initialStateAddMoney = createFormGroupState<IAddMoney>(ADDMONEY, {
  value: 0
})

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
  id: "",
  email: "",
  name: "",
  login: "",
  secureKey: ""
}

const initialStateCurrency : ICurrency = {
  name: '',
  purchase: 0,
  sale: 0,
  securityCode: 0,
  validFrom: '',
  validTo: ''
}

const initialStateExchange = createFormGroupState<IExchange>(EXCHANGE, {
  amount: 0,
  isSale: false,
  currency: ''
})

const initialState: IPanelState = {
  user: initialStateUserDetails,
  currencies: [],
  userAccountBalances: [],
  userHistory: [],
  userOperationHistory: [],
  exchange: initialStateExchange,
  addMoneyRequest: initialStateAddMoney,
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
    on( GetCurrenciesSuccess, (state, action) => {
        return { ...state,
          currencies: action.data.currencies
        }
    })
)

export function panelReducer(state: any, action: any) {
    return _panelReducer(state, action);
}