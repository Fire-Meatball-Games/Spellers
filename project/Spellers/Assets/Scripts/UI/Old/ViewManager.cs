using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private View startingView;
    [SerializeField] private List<View> views;

    private readonly Stack<View> viewStack = new Stack<View>();
    private View activeView;

    private static ViewManager instance;

    public static T GetView<T>() where T : View
    {
        foreach(View view in instance.views)
        {
            if (view is T tView)
                return tView;
        }
        return null;
    }

    public static void Show<T>(bool saveOnStack = true) where T : View
    {
        View view = GetView<T>();
        if(view != null)
        {
            if (instance.activeView != null)
            {
                if (saveOnStack)
                {
                    instance.viewStack.Push(instance.activeView);
                }
                instance.activeView.Hide();
            }
            view.Show();
            instance.activeView = view;                   
        }
    }

    public static void Show(View view, bool savedOnStack = true)
    {
        if(instance.activeView != null)
        {
            if (savedOnStack)
            {
                instance.viewStack.Push(instance.activeView);
            }                
            instance.activeView.Hide();
        }

        view.Show();
        instance.activeView = view;
    }

    public static void ShowLast()
    {        
        if (instance.viewStack.Count != 0)
        {
            Show(instance.viewStack.Pop(), false);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var view in views)
        {
            view.Init();
            view.Hide();
        }

        if (startingView != null)
            Show(startingView, true);
    }

}
