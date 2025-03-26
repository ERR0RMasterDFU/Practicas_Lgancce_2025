import { Component, Input } from '@angular/core';
import { GetActorDtoSimple } from '../../../interfaces/actor.interfaces';

@Component({
  selector: 'app-actor-card',
  standalone: false,
  templateUrl: './actor-card.component.html',
  styleUrl: './actor-card.component.css'
})
export class ActorCardComponent {

  @Input() actor: GetActorDtoSimple | undefined;

}
