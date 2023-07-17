import { HttpClient } from '@angular/common/http';
import {Injectable} from'@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/Environment';

@Injectable({
  providedIn: 'root'
})

export class PodcastService{

  public selectedPodcast = new Subject<any>();
  podcastSelected = this.selectedPodcast.asObservable();

  constructor(private http: HttpClient){}
  public getAllPodcasts(): Observable<any>{

    return this.http.get(environment.api + 'Podcast', { withCredentials: true } )
  }
  public getAllPodcastGroups(): Observable<any>{
    return this.http.get(environment.api + 'PodcastGroup', { withCredentials: true } )
  }
  public deletePodcast(podcastDto:any): Observable<any> {
    return this.http.delete(environment.api + 'Podcast/' + podcastDto, { withCredentials: true });
  }


  public AddPodcast(podcastDto: any){
    this.http.post(environment.api + 'Podcast' ,
    {
      title: podcastDto.title,
      publishDate: podcastDto.publishDate,
      description: podcastDto.description,
      voiceAddress: podcastDto.voiceAddress,
      groupID: podcastDto.groupID
    }, { withCredentials: true }
    ).subscribe(res =>{
      console.log(res);
    })
  }
  selectPodcast(podcast: any)
  {
    setTimeout(()=>{
      this.selectedPodcast.next(podcast);
    },10);
  }

  public EditPodcast(podcastDto: any){
    this.http.put(environment.api + 'Podcast/' + podcastDto.id, podcastDto, { withCredentials: true }).subscribe(res => {
      console.log(res);
    });
  }


}
