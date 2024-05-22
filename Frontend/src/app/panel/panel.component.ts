import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ICurrency, IPanelState, IUserBalance, IUserDetails, IUserHistory, IUserOperationHistory, getCurrencies, getUserAccountBalance, getUserDetails, getUserHistory, getUserOperationHistory } from '../../store/panel/panel.reducer';
import { Store } from '@ngrx/store';
import { GetCurrencies, GetUserDetails } from '../../store/panel/panel.actions';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrl: './panel.component.scss'
})

export class PanelComponent {
  operationHistoryColumns: string[] = ['date', 'value', 'exchangeRate', 'totalValue', 'currencyCode', 'operationType'];
  historyColumns: string[] = ['action', 'date'];
  accountBalancesColumns: string[] = ['currency', 'balance'];
  currenciesColumns: string[] = ['name', 'purchase', 'sale'];
  
  public userDetails$: Observable<IUserDetails>;
  public currencies$: Observable<ICurrency[]>;
  public userAccountBalance$: Observable<IUserBalance[]>;
  public userHistory$: Observable<IUserHistory[]>;
  public userOperationHistory$: Observable<IUserOperationHistory[]>;

  constructor(private store: Store<IPanelState>){
    this.store.dispatch(GetUserDetails());
    this.store.dispatch(GetCurrencies());
    
    this.userDetails$ = this.store.select(getUserDetails);
    this.currencies$ = this.store.select(getCurrencies);
    this.userAccountBalance$ = this.store.select(getUserAccountBalance);
    this.userHistory$ = this.store.select(getUserHistory);
    this.userOperationHistory$ = this.store.select(getUserOperationHistory);
  }
}

