module LazyFactory

open SingleThreadedLazy
open ILazy
open LazyConcurrent
open LazyLockFree

type LazyFactory =
    static member CreateSingleThreadedLazy (supplier : unit -> 'a) =
        new Lazy<'a> (supplier) :> ILazy<'a>
        
    static member CreateConcurrentLazy (supplier : unit -> 'a) =
        new LazyConcurrent<'a> (supplier) :> ILazy<'a>
        
    static member CreateLockFreeLazy (supplier : unit -> 'a) =
        new LazyLockFree<'a> (supplier) :> ILazy<'a>