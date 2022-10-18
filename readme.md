# ugs-free
  [old-sheets](https://github.com/shlifedev/ugs-core-old) 재구현



## Development Setup Guide
### Apps Script Push & Deploy 
 NPM 에 전역으로 clasp 설치가 필요합니다.
 ```
 npm i @google/clasp -g
 ```
 이후 생성한 스크립트에 
 [here](https://script.google.com) 에서 스크립트 생성후 URL에서 `Script Id` 복사 및 `Apps script API` 활성화
 ```
 clasp login 
 clasp clone [script id] 
 ```
 `deploy`를 `위해 packages.json`에서도 `deployId` 값을 수정해야합니다. 배포된 `deploy`가 없다면 `clasp deploy` 로 먼저 새로운 `deployId` 를 생성하세요.
 ```
  "dev": "clasp push && clasp deploy -i [deployId]" 
 ```
