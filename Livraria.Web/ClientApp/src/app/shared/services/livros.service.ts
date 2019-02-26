import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Livro } from '../model/livro.model';
import { Retorno } from '../model/retorno.model';
@Injectable()
export class LivroService {
  public _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  getLivro(ISBN: string) {
    return this._http.get<Livro>('/api/Livros/' + ISBN);
  }

  getLivros() {
    return this._http.get<Retorno>('/api/Livros/');
  }

  CriarLivro(livro: Livro) {
    return this._http.post('/api/Livros', livro);
  }

  EditarLivro(livro: Livro) {
    return this._http.put('/api/Livros/' + livro.isbn, livro);
  }

  DeletarLivro(ISBN: string) {
    return this._http.delete('/api/Livros/' + ISBN);
  }

}
