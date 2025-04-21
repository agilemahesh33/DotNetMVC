import { CommonModule } from '@angular/common';

export interface Story {
  id: number;
  title: string;
  url: string;
  by: string;
  score: number;
  time: number;
}
export class StoryModule { }
