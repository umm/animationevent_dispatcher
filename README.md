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

## Animation 側

* AnimatorController がアタッチされている GameObject に `AnimationEventDispatcher` をアタッチします
* Animation の AnimationEvent の設定として `AnimationEventDispatcher.DispatchEvent()` を呼び出します
    * その際、1つ以上の `int`, `float`, `string`, `object` をパラメータとして渡せます
    * `string` を用いて「何の AnimationEvent なのか？」を渡すと見通しが良くなりそうです

## Script 側

* `AnimationEventDispatcher.OnDispatchEventAsObservable()` が返す `IObservable<AnimationEvent>` を Subscribe します
* `OnDispatchEventAsObservable()` *引数: なし* は全ての `DispatchEvent()` を流します
    * `.Where()` などでフィルタリングすることをオススメします
* `OnDispatchEventAsObservable()` *引数: int, float, string, object* は引数に渡した値にマッチする `DispatchEvent()` を流します
    * 複合条件には対応していないので、複雑な条件を付ける場合は *引数なし* を呼んで、自分でストリームをフィルタしてください

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

## Included Asset

* テスト用の音声ファイル (`Assets/Tests/Sounds/Audio.mp3`) は [無料効果音素材](http://taira-komori.jpn.org/freesound.html) からダウンロードしております

