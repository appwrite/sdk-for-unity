# Change Log

## 0.6.0

* Breaking: `Execution.FunctionId` replaced by `ResourceId` and `ResourceType` (`ExecutionResourceType`)
* Breaking: `Storage.CreateFile` gains `folder` parameter before `onProgress`; positional callers must update
* Breaking: `AppwriteService` flag values shifted by new `DocumentsDB`, `Organization`, `VectorsDB` bits; re-save custom `AppwriteConfig` assets
* Breaking: SDK now targets Appwrite 2.0 (`X-Appwrite-Response-Format: 2.0.0`)
* Added: `DocumentsDB` and `VectorsDB` services for document and vector database access
* Added: `Organization` service with `ListInstallations`, `CreateInstallation`, `GetInstallation`, `UpdateInstallation`, `DeleteInstallation`
* Added: `Teams` installation methods `ListInstallations`, `CreateInstallation`, `GetInstallation`, `UpdateInstallation`, `DeleteInstallation`
* Added: `Account` consent methods `ListConsents`, `GetConsent`, `DeleteConsent`, `ListConsentTokens`, `GetConsentToken`, `DeleteConsentToken`
* Added: `Avatars.GetPhoto` returning the best available user profile photo
* Added: `Folder` parameter to `Storage.CreateFile` and `Folder`, `Key` fields on `File`
* Added: `AppInstallation`, `Oauth2Consent`, `Oauth2ConsentToken` models and their list models
* Added: `Custom` value to `AuthenticationFactor` enum and `MfaFactors.Custom` field
* Added: `Cloudflare`, `Huggingface`, `Resend` values to `OAuthProvider` enum
* Updated: `Presence.Metadata` and `User.HashOptions` expose raw objects instead of strings

## 0.5.0

* Added: `Client` header setters `SetProject`, `SetBearer`, `SetLocale`, `SetSession`, `SetDevKey`, `SetCookie`
* Added: `Client` impersonation setters `SetImpersonateUserId`, `SetImpersonateUserEmail`, `SetImpersonateUserPhone`
* Added: `Query.VectorDot`, `Query.VectorCosine`, `Query.VectorEuclidean` vector search queries
* Added: `Appwrite` value to `OAuthProvider` enum
* Added: geolocation and connection fields (`City`, `TimeZone`, `Latitude`, `Isp`, etc.) to `Locale` model

## 0.4.0

* Added: Realtime connections now send an `x-appwrite-jwt` header for authentication.

## 0.3.0

* Added: `userAccessedAt` field to the `Membership` model.
* Added: Email metadata fields to `User` (`emailCanonical`, `emailIsFree`, `emailIsDisposable`, `emailIsCorporate`, `emailIsCanonical`).
* Updated: Requests now send an explicit `accept` header matching each endpoint's response type.

## 0.2.1

* Fixed: `AndroidManifest.xml` now imports as an Android plugin instead of a generic asset
* Added: `author` field to `package.json`
* Updated: README pins the UPM install URL to the release tag (`#0.2.1`)

## 0.2.0

* Breaking: Install URL changed — drop `?path=Assets`, the package now lives at the repo root
* Updated: Restructured SDK as a proper UPM package (`Runtime`, `Editor`, `Samples~`)
* Added: `.meta` files for all scripts, folders, and assets for stable Unity GUIDs
* Added: `Oauth2Grant` model

## 0.1.0

* Added: Initial beta release of the Appwrite Unity SDK
* Added: Support for Appwrite server version `1.9.x`
* Added: `Account`, `Databases`, `TablesDB`, `Storage`, `Functions`, `Teams`, `Messaging`, `Locale`, `Avatars`, and `Graphql` services
* Added: Realtime subscriptions via `Channel`
* Added: Unity Package Manager installation with editor setup assistant
