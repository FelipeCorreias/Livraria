import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { LivroService } from '../../shared/services/livros.service';
import { Livro } from '../../shared/model/livro.model';


@Component({
  selector: 'app-livro-edit',
  templateUrl: './livro-edit.component.html'
})
export class LivroEditComponent implements OnInit {
  public livro: Livro;
  public isbn: string;
  public formularioEnviado: boolean = false;
  public erroEnviarFormulario: boolean = false;
  public _livroService: LivroService;
  public _route: ActivatedRoute;

  constructor(private livroService: LivroService, private route: ActivatedRoute) {
    this._livroService = livroService;
    this._route = route;


  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this._livroService.getLivro(params['isbn']).subscribe(data => { this.livro = data; });
      this.isbn = params['isbn'];
    });
  }

  submit(form) {
    this.livro = form.value;
    this.livro.isbn = this.isbn;
    console.log(this.livro);
    this._livroService.EditarLivro(this.livro).subscribe(suc => {
      //form.reset();
      this.formularioEnviado = true;
      this.erroEnviarFormulario = false;
    },
      err => {
        this.formularioEnviado = false;
        this.erroEnviarFormulario = true;
      });
   
  }

}
