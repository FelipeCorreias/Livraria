import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { LivroService } from '../../shared/services/livros.service';
import { Livro } from '../../shared/model/livro.model';
import { Retorno } from '../../shared/model/retorno.model';

@Component({
  selector: 'app-livro-list',
  templateUrl: './livro-list.component.html'
})
export class LivroListComponent implements OnInit {
  dtOptions: any = {};
  public livros: Livro[];
  public _livroService: LivroService;
  public _route: ActivatedRoute;

  constructor(private livroService: LivroService, private route: ActivatedRoute) {
    this._livroService = livroService;
    this._route = route;
  }

  ngOnInit() {

    this._route.params.subscribe(params => {
      this.livros = null;
      this.getLivros();
    });

    this.dtOptions = {
      pageLength: 25,
      responsive: true
    };
  }

  getLivros() {
    this._livroService.getLivros().subscribe(data => { this.livros = data.data; })
      , err => {
        console.log(err);
      };
  }

  delete(ISBN: string) {
    this._livroService.DeletarLivro(ISBN).subscribe();
    this.livros = this.livros.filter((elem) => {
      return elem.isbn !== ISBN;
    });
  }

}
