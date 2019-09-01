# 네트워크 시스템 개념  
### 서버와 호스트  

unity 네트워킹 시스템에서, 게임은 하나의 서버와 여러 클라이언트를 가진다.  
그러나 전용 서버가 없을 경우, 클라이언트 중 하나가 서버의 역할을 하게 된다.  
해당 서버가 되는 클라이언트를 _호스트_ 라고 한다.  
또한, 이러한 서버 시스템을 _Listen server_ 라고 한다.  

![Alt text](https://docs.unity3d.com/kr/530/uploads/Main/NetworkHost.png "https://docs.unity3d.com/kr/530/uploads/Main/NetworkHost.png")  

호스트는 서버이자, 동일한 프로세스 안의 클라이언트이다.  
호스트는 _LocalClient_ 라는 특수한 클라이언트를 사용하며,  
다른 클라이언트들은 _RemoteClient_ 를 사용한다.  
LocalClient는 직접적인 함수 호출 및 메시지 큐를 통하여 로컬 서버와 통신한다.  
LocalClient는 사실상 씬을 서버와 공유하게 된다.  
RemoteClient는 정기적인 네트워크 커넥션에 의해 서버와 통신하게 된다.  

네트워킹 시스템의 목적은 LocalClient와 RemoteClient 코드를 동일하게 하여, 개발자가 대부분의 시간에 한 종류의 클라이언트만 생각할 수 있도록 하는것이다.  
```- 본인은 이 부분에 대해, 개발 과정에서 한 종류의 클라이언트만 개발할 수 있도록 하는 것이 목적이다 라고 해석하고 있다.```  
### 인스턴스화(Instantiate)와 스폰(Spwan)  

Unity에서는 GameObject.Instantiate라는 메서드에 의해 새 게임 오브젝트가 생성된다. 그러나 네트워킹 시스템에서는 오브젝트가 네트워크에서 활성화되기 위해서는 해당 오브젝트가 _스폰(Spawn)_ 되어야 한다.  
이것은 서버에서만 할 수 있으며, 연결된 클라이언트(RemoteClient)에서도 오브젝트 들이 생성되게끔 한다. 오브젝트가 스폰된 이후에는 스포닝 시스템(Spawning System)이 오브젝트 라이프-사이클 관리와 상태 동기화를 한다.  


2019.09.01 작성중, Unity Documentation :: 네트워크 시스템 개념 <https://docs.unity3d.com/kr/530/Manual/UNetConcepts.html> 에서 발췌