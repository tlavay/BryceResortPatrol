import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PublicClientApplication } from '@azure/msal-browser';

/*public*/
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AboutComponent } from './about/about.component';
import { CandidacyComponent } from './candidacy/candidacy.component';
import { HistoryComponent } from './history/history.component';
import { JoinComponent } from './join/join.component';

/*members*/
import { MemberComponent } from './member-components/member/member.component';
import { ScheduleComponent } from './member-components/schedule/schedule.component';
import { AuthComponent } from './member-components/auth/auth.component';

/*services*/
import { Api } from './services/api.services';
import { MsalModule } from '@azure/msal-angular';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    AboutComponent,
    CandidacyComponent,
    HistoryComponent,
    JoinComponent,
    ScheduleComponent,
    MemberComponent,
    AuthComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MsalModule.forRoot(new PublicClientApplication({
      auth: {
        clientId: 'fdad1697-c941-43e2-ba32-74e3916b42f4', // Application (client) ID from the app registration
        authority: 'https://login.microsoftonline.com/a53917c1-e37e-4708-b58d-c332638a194a', // The Azure cloud instance and the app's sign-in audience (tenant ID, common, organizations, or consumers)
        redirectUri: 'https://localhost:5001/'// This is your redirect URI
      },
      cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: false, // Set to true for Internet Explorer 11
      }
    }), null, null),
    RouterModule.forRoot([
      { path: '', component: AboutComponent },
      { path: 'history', component: HistoryComponent },
      { path: 'schedule', component: ScheduleComponent },
      { path: 'join', component: JoinComponent },
      { path: 'about', component: AboutComponent },
      { path: 'candidacy', component: CandidacyComponent },
      { path: 'members/members', component: MemberComponent },
      { path: 'members/schedule', component: ScheduleComponent },
      { path: '**', redirectTo: 'about' },
    ])
  ],
  providers: [Api],
  bootstrap: [AppComponent]
})
export class AppModule { }
