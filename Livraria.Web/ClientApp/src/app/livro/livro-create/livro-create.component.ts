import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { LivroService } from '../../shared/services/livros.service';
import { Livro } from '../../shared/model/livro.model';

@Component({
  selector: 'app-livro-create',
  templateUrl: './livro-create.component.html'
})
export class LivroListComponent implements OnInit {
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



  delete(ISBN: string) {
    this._livroService.DeletarLivro(ISBN).subscribe();
    this.livros = this.livros.filter((elem) => {
      return elem.isbn !== ISBN;
    });
  }

}
