import { Component } from '@angular/core';
import { FormGroupState } from 'ngrx-forms';
import { Observable } from 'rxjs';
import { IAuthState, ICredentials, getCredentials, getError } from '../../store/auth/auth.reducer';
import { Store } from '@ngrx/store';
import { login, register } from '../../store/auth/auth.actions';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss'
})

export class AuthComponent {

  credentials$: Observable<FormGroupState<ICredentials>>
  error$: Observable<boolean>

  constructor(private store: Store<IAuthState>){
    this.credentials$ = this.store.select(getCredentials);
    this.error$ = this.store.select(getError);
  }

  login(){
    this.store.dispatch(login());
  }
  
  register(){
    this.store.dispatch(register());
  }
}
