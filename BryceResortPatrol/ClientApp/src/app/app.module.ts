import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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
    RouterModule.forRoot([
      { path: '', component: AboutComponent },
      { path: 'history', component: HistoryComponent },
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
