import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { CandidacyComponent } from './candidacy/candidacy.component';
import { HistoryComponent } from './history/history.component';
import { JoinComponent } from './join/join.component';
//import { SignIn } from './sign-in/sign-in.component';

//import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { Api } from './services/api.services';
import { AuthGuard } from './services/auth-guard.services';
import { AuthService } from './services/auth.services';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { DataSharingService } from './services/data-sharing.services';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutComponent,
    CandidacyComponent,
    HistoryComponent,
    JoinComponent,
    //SignIn
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //FontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }, ,
      //{ path: 'sign-in', component: SignIn },
      { path: 'history', component: HomeComponent, pathMatch: 'full' },
      { path: 'join', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: HomeComponent, pathMatch: 'full' },
      { path: 'candidacy', component: HomeComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    Api,
    AuthService,
    JwtHelperService,
    DataSharingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
