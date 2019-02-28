import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { LivroService } from '../../shared/services/livros.service';
import { Livro } from '../../shared/model/livro.model';

@Component({
  selector: 'app-livro-create',
  templateUrl: './livro-create.component.html'
})
export class LivroCreateComponent implements OnInit {
  public livro: Livro;
  public file: File;
  public formularioEnviado: boolean = false;
  public erroEnviarFormulario: boolean = false;
  public _livroService: LivroService;
  public _route: ActivatedRoute;

  constructor(private livroService: LivroService, private route: ActivatedRoute) {
    this._livroService = livroService;
    this._route = route;
  }

  ngOnInit() {

  }

  submit(form) {
    this.livro = form.value;
    console.log(this.livro);
    this.livro.capa = this.file;
    this._livroService.CriarLivro(this.livro).subscribe(suc => {
      form.reset();
      this.formularioEnviado = true;
      this.erroEnviarFormulario = false;
    },
      err => {
        this.formularioEnviado = false;
        this.erroEnviarFormulario = true;
      });
   
  }

  onFileChange(event) {
    this.file = event.target.files[0];
  }

}
