import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AboutComponent } from './about/about.component';
import { CandidacyComponent } from './candidacy/candidacy.component';
import { HistoryComponent } from './history/history.component';
import { JoinComponent } from './join/join.component';

import { Api } from './services/api.services';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    AboutComponent,
    CandidacyComponent,
    HistoryComponent,
    JoinComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AboutComponent, pathMatch: 'full' },
      { path: 'history', component: HistoryComponent, pathMatch: 'full' },
      { path: 'join', component: JoinComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent, pathMatch: 'full' },
      { path: 'candidacy', component: CandidacyComponent, pathMatch: 'full' },
      { path: '**', redirectTo: 'about' },
    ])
  ],
  providers: [Api],
  bootstrap: [AppComponent]
})
export class AppModule { }
