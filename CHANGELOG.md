# Change Log

## 0.3.0

* Added: `userAccessedAt` field to the `Membership` model.
* Added: Email metadata fields to `User` (`emailCanonical`, `emailIsFree`, `emailIsDisposable`, `emailIsCorporate`, `emailIsCanonical`).

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
