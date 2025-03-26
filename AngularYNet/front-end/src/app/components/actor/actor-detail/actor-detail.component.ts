import { Component } from '@angular/core';
import { GetActorDtoCompleto } from '../../../interfaces/actor.interfaces';
import { ActorService } from '../../../services/actor.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-actor-detail',
  standalone: false,
  templateUrl: './actor-detail.component.html',
  styleUrl: './actor-detail.component.css'
})
export class ActorDetailComponent {

  actorId: string | null = "";
  actor: GetActorDtoCompleto | undefined;

  constructor(
    private actorService: ActorService, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.actorId = this.route.snapshot.paramMap.get('id');

    if (this.actorId) {
      const generoIdNum = parseInt(this.actorId);

      this.actorService.getActorById(generoIdNum).subscribe(respuesta => {
        this.actor = respuesta;
      });

    }

  }

}

