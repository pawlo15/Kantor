import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ICurrency, IExchange, IPanelState, IUserBalance, IUserDetails, IUserHistory, IUserOperationHistory, getCurrencies, getExchange, getUserAccountBalance, getUserDetails, getUserHistory, getUserOperationHistory } from '../../store/panel/panel.reducer';
import { Store } from '@ngrx/store';
import { ExchangeCurrency, GetCurrencies, GetUserDetails } from '../../store/panel/panel.actions';
import { FormGroupState } from 'ngrx-forms';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrl: './panel.component.scss'
})

export class PanelComponent {
  operationHistoryColumns: string[] = ['date', 'currencyCode', 'value', 'exchangeRate', 'totalValue', 'operationType'];
  historyColumns: string[] = ['action', 'date'];
  accountBalancesColumns: string[] = ['currency', 'balance'];
  currenciesColumns: string[] = ['name', 'purchase', 'sale'];


  public exchange$: Observable<FormGroupState<IExchange>>;

  userDetails$: Observable<IUserDetails>;
  public currencies$: Observable<ICurrency[]>;
  userAccountBalance$: Observable<IUserBalance[]>;
  userHistory$: Observable<IUserHistory[]>;
  userOperationHistory$: Observable<IUserOperationHistory[]>;

  constructor(private store: Store<IPanelState>){
    this.store.dispatch(GetUserDetails());
    this.store.dispatch(GetCurrencies());
    
    this.exchange$ = this.store.select(getExchange);
    this.userDetails$ = this.store.select(getUserDetails);
    this.currencies$ = this.store.select(getCurrencies);
    this.userAccountBalance$ = this.store.select(getUserAccountBalance);
    this.userHistory$ = this.store.select(getUserHistory);
    this.userOperationHistory$ = this.store.select(getUserOperationHistory);
  }

  logout(){
    console.log("wylogowanie")
  }

  exchangeRequest(){
    console.log("Wymiana");
    this.store.dispatch(ExchangeCurrency());
  }
}

