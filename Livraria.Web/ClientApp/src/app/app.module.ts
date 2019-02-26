import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LivroComponent } from './livro/livro.component';
import { LivroListComponent } from './livro/livro-list/livro-list.component';

import { LivroService } from './shared/services/livros.service'; 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LivroComponent,
    LivroListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LivroComponent, pathMatch: 'full' }
    ])
  ],
  providers: [LivroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
