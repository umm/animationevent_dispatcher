# What?

* Animation の AnimationEvent 機能から呼び出し可能な汎用 Dispatcher

# Why?

* エンジニアとデザイナー (アニメーター) とのコミュニケーションコストを下げたかった
    * 先に Script 側にメソッド定義していないと AnimationEvent で呼び出しできない
    * しかし Script が先行して実装されているケースが少ない
    * そのため、コミュニケーションの往復回数が多くなる

# Install

```shell
$ nom install @umm/animationevent_dispatcher
```

# Usage

## GeneralDispatcher

### Animation 側

* AnimatorController がアタッチされている GameObject に `GeneralDispatcher` をアタッチします
* Animation の AnimationEvent の設定として `GeneralDispatcher.Dispatch()` を呼び出します
    * その際、1つ以上の `int`, `float`, `string`, `object` をパラメータとして渡せます
    * `string` を用いて「何の AnimationEvent なのか？」を渡すと見通しが良くなりそうです

### Script 側

* `GeneralDispatcher.OnDispatchAsObservable()` が返す `IObservable<AnimationEvent>` を Subscribe します
* `OnDispatchAsObservable()` *引数: なし* は全ての `AnimationEvent` を流します
    * `.Where()` などでフィルタリングすることをオススメします
* `OnDispatchAsObservable()` *引数: int, float, string, object* は引数に渡した値にマッチする `AnimationEvent` を流します
    * 複合条件には対応していないので、複雑な条件を付ける場合は *引数なし* を呼んで、自分でストリームをフィルタしてください

## AudioDispatcher

### Animation 側

* AnimatorController がアタッチされている GameObject に `AudioDispatcher` をアタッチします
* Animation の AnimationEvent の設定として `AudioDispatcher.Play()` を呼び出します
    * その際、 AudioClip をパラメータとして渡します
* これで、当該 AnimationEvent を通過した瞬間にパラメータに渡した AudioClip が再生されます

### Script 側

* 「発音が始まった瞬間」を検知することができます
* 検知する場合は `AudioDispatcher.OnDispatchAsObservable()` が返す `IObservable<AnimationEvent>` を Subscribe します

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

## Included Asset

* テスト用の音声ファイル (`Assets/Tests/Sounds/Audio.mp3`) は [無料効果音素材](http://taira-komori.jpn.org/freesound.html) からダウンロードしております

