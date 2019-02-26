import { Livro } from './livro.model';

export interface Retorno {
  totalRows?: number;
  data?: Array<Livro>;
}
