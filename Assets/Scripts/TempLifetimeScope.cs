using DBU;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TempModel : IBindModel
{
    public string var1;
    public string var2;
}

public class TempModel2 : IBindModel
{
    public int var1;
}

[InjectorModel(typeof(TempModel), typeof(TempModel2))]
public partial class TempLifetimeScope : UIBaseLifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        builder.RegisterEntryPoint<TempMessagePipe>(Lifetime.Singleton);
    }
}

public class TempMessagePipe : IStartable
{
    public TempMessagePipe(IPublisher<string, string> pub, ISubscriber<string, string> sub,
        IPublisher<string, int> pub2, ISubscriber<string, int> sub2)
    {
        _pub = pub;
        _sub = sub;

        _sub.Subscribe("test", parameter =>
        {
            Debug.Log(parameter);
        });
    }

    private IPublisher<string, string> _pub;
    private ISubscriber<string, string> _sub;
    public void Start()
    {
        _pub.Publish("test", "test");
    }
}
