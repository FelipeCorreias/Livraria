import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgxMaskModule } from 'ngx-mask';
import { CurrencyMaskModule } from "ngx-currency-mask";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LivroComponent } from './livro/livro.component';
import { LivroListComponent } from './livro/livro-list/livro-list.component';
import { LivroCreateComponent } from './livro/livro-create/livro-create.component';
import { LivroEditComponent } from './livro/livro-edit/livro-edit.component';
import { LivroService } from './shared/services/livros.service'; 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LivroComponent,
    LivroListComponent,
    LivroCreateComponent,
    LivroEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgxMaskModule.forRoot(),
    CurrencyMaskModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LivroComponent, pathMatch: 'full' },
      { path: 'livro/create', component: LivroCreateComponent, pathMatch: 'full' },
      { path: 'livro/edit/:isbn', component: LivroEditComponent, pathMatch: 'full' }
    ])
  ],
  providers: [LivroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
