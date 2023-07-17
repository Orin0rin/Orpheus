import { HttpClient } from '@angular/common/http';
import {Injectable} from'@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/Environment';

@Injectable({
  providedIn: 'root'
})

export class PodcastUserService{

  public selectedPodcast = new Subject<any>();
  podcastSelected = this.selectedPodcast.asObservable();

  constructor(private http: HttpClient){}
  public getAllPodcasts(): Observable<any>{

    return this.http.get(environment.api + 'Podcast' , { withCredentials: true })
  }
  public getAllPodcastGroups(): Observable<any>{
    return this.http.get(environment.api + 'PodcastGroup' , { withCredentials: true })
  }


  selectPodcast(podcast: any)
  {
    setTimeout(()=>{
      this.selectedPodcast.next(podcast);
    },10);
  }

}
