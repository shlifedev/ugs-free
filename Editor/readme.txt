# UIElement.ElementTreeAssetBase<T>
 - 기존 Uxml 작업방식을 간소화 시키고 파일이름 및 컴포넌트의 통일성을 지킬 수 있게함
 - CloneTree(target) 이 `source` 와 `created` 된 element를 모두 리턴하면 TemplateContainer가 없어도 `Query`에 딱히 문제없음.


## 사용방법
 1. `ElementTreeAssetBase<T>`를 상속, `T` 에는 컴포넌트명 입력 (없을시 Visual Element)
 2. ElementTreeAssetBase 생성자에서 필요한 모든작업 (쿼리빌드, 로직연결) 마치면 됨 
 
 
 3. 제네릭이 제공되는 T는 딱히 안써도 됨. Root Component, 인터널 클래스로 선언 추천, 필요에의해 컴포넌트를 정의한경우 2번작업을 생략하고 Uxml C# Component 형태로 작업해도 됨 (단 파일을 로드하고 CloneTree하는 로직은 이 클래스에 위임)
 
 사실 UI 빌더에서 사용하지 않을거라면 3번 제네릭은 그냥 VisualElement로 고정하면 좋음.
