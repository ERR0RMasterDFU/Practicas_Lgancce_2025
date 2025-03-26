import { Component, OnInit } from '@angular/core';
import { GeneroService } from '../../../services/genero.service';
import { ActivatedRoute } from '@angular/router';
import { GeneroResponse } from '../../../interfaces/genero.interfaces';

@Component({
  selector: 'app-genero-details',
  standalone: false,
  templateUrl: './genero-details.component.html',
  styleUrl: './genero-details.component.css'
})
export class GeneroDetailsComponent implements OnInit {

  generoId: string | null = "";
  genero: GeneroResponse | undefined;

  constructor(
    private generoService: GeneroService, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.generoId = this.route.snapshot.paramMap.get('id');

    if (this.generoId) {
      const generoIdNum = parseInt(this.generoId);

      this.generoService.getGeneroById(generoIdNum).subscribe(respuesta => {
        this.genero = respuesta;
      });

    }

  }

}
