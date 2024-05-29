import { Component } from '@angular/core';
import { FormGroupState } from 'ngrx-forms';
import { Observable } from 'rxjs';
import { IAuthState, ICredentials } from '../../store/auth/auth.reducer';
import { IRegistrationDetails, IRegistrationState, getRegistrationDetails } from '../../store/registration/registration.reducer';
import { Store } from '@ngrx/store';
import { registration } from '../../store/registration/registration.actions';
import { navigateToLoginPage } from '../../store/auth/auth.actions';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  details$: Observable<FormGroupState<IRegistrationDetails>>;

  constructor(private store: Store<IRegistrationState>, private authStore: Store<IAuthState>){
    this.details$ = this.store.select(getRegistrationDetails);
  }

  register(){
    this.store.dispatch(registration());
  }

  back(){
    this.authStore.dispatch(navigateToLoginPage());
  }
}
