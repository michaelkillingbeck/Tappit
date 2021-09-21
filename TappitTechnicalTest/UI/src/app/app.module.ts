import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PeopleListComponent } from './people/people-list.component';
import { PersonDetailComponent } from './people/person-detail.component';
import { ConcatSports } from './shared/concat-sports';
import { FavouriteSportsList } from './sports/favourite-sports.component';

@NgModule({
  declarations: [
    AppComponent,
    ConcatSports,
    PeopleListComponent,
    PersonDetailComponent,
    FavouriteSportsList
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'people',       component: PeopleListComponent },
      { path: 'person/:id',   component: PersonDetailComponent },
      { path: 'sports',   component: FavouriteSportsList },
      { path: '', redirectTo: 'people', pathMatch: 'full' },
      { path: '**', redirectTo: 'people', pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
